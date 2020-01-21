/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * <h2><center>&copy; Copyright (c) 2019 STMicroelectronics.
  * All rights reserved.</center></h2>
  *
  * This software component is licensed by ST under BSD 3-Clause license,
  * the "License"; You may not use this file except in compliance with the
  * License. You may obtain a copy of the License at:
  *                        opensource.org/licenses/BSD-3-Clause
  *
  ******************************************************************************
  */
/* USER CODE END Header */

/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "adc.h"
#include "can.h"
#include "i2c.h"
#include "usart.h"
#include "gpio.h"
#include "stdbool.h"
#include "stdio.h"
#include "stdlib.h"
#include "gesture.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include "VL53L1X_api.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */
uint8_t TxBuff[96]; //48
uint8_t RxBuff[96];

//PSOTTY_START
uint16_t data[4][LEN];
uint16_t *ptrData;
uint16_t *const ptrDataStart = &data[0][0];
uint16_t *const ptrDataEnd = &data[3][LEN-1];
uint8_t counter = 0, counterOut = 0;

uint16_t messageBody[4];
//PSOTTY_END

uint8_t sensorsDataReady = 0b00000000;

int status;
uint16_t rangeDistances[4] = {0,0,0,0};
uint8_t numberOfDevices = 4;

uint16_t distance;

VL53L1_Dev_t                   dev1;
VL53L1_Dev_t                   dev2;
VL53L1_Dev_t                   dev3;
VL53L1_Dev_t                   dev4;
VL53L1_DEV					   arrayDevices[4];
VL53L1_Dev_t                   devBASE;
VL53L1_DEV					   DEVBASE;

//uint16_t LightIN;
//float LightINmV;
//float ADCconvert=0.7326;

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
/* USER CODE BEGIN PFP */
void processUartMessagge();
void sendMessage();

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void) {
  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* Configure the system clock */
  SystemClock_Config();

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_CAN_Init();
  MX_USART1_UART_Init();
  MX_ADC1_Init();
  MX_I2C1_Init();
  /* USER CODE BEGIN 2 */


  //Set up devices I2C adress and I2C handler
  DEVBASE = &devBASE;
  DEVBASE->I2Chandle = &hi2c1;
  DEVBASE->I2cDevAddr = 0x52;

  arrayDevices[0] = &dev1;
  arrayDevices[1] = &dev2;
  arrayDevices[2] = &dev3;
  arrayDevices[3] = &dev4;
  arrayDevices[0]->I2cDevAddr = 0x10;
  arrayDevices[0]->I2Chandle = &hi2c1;
  arrayDevices[1]->I2cDevAddr = 0x20;
  arrayDevices[1]->I2Chandle = &hi2c1;
  arrayDevices[2]->I2cDevAddr = 0x30;
  arrayDevices[2]->I2Chandle = &hi2c1;
  arrayDevices[3]->I2cDevAddr = 0x40;
  arrayDevices[3]->I2Chandle = &hi2c1;


     HAL_GPIO_WritePin(XShut_1_GPIO_Port, XShut_1_Pin, GPIO_PIN_RESET);
     HAL_GPIO_WritePin(XShut_2_GPIO_Port, XShut_2_Pin, GPIO_PIN_RESET);
     HAL_GPIO_WritePin(XShut_3_GPIO_Port, XShut_3_Pin, GPIO_PIN_RESET);
     HAL_GPIO_WritePin(XShut_4_GPIO_Port, XShut_4_Pin, GPIO_PIN_RESET);

  for(int i=1;i<(numberOfDevices+1);i++) {
	  chooseDevice(i);
	  HAL_Delay(100);
  	  status = VL53L1X_SensorInit(*DEVBASE);
  	  status = VL53L1X_SetI2CAddress(*DEVBASE,arrayDevices[i-1]->I2cDevAddr);
 	  status = VL53L1X_SetInterMeasurementInMs(*arrayDevices[i-1],50);    // !!! 100 !!!
 	  status = VL53L1X_SetTimingBudgetInMs(*arrayDevices[i-1],50);
 	  status = VL53L1X_SetInterruptPolarity(*arrayDevices[i-1], 0); //0= active low
 	  status = VL53L1X_StartRanging(*arrayDevices[i-1]);
   }

  //Start ADC
  //HAL_ADC_Start(&hadc1);

  HAL_HalfDuplex_EnableReceiver(&huart1);
  //Function which sets up pointer to UART receive buffer and number of characters which will be received
  HAL_UART_Receive_IT(&huart1, RxBuff, 1);

  HAL_NVIC_EnableIRQ(USART1_IRQn);
  HAL_NVIC_ClearPendingIRQ(USART1_IRQn);
  HAL_NVIC_EnableIRQ(EXTI9_5_IRQn);
  HAL_NVIC_EnableIRQ(EXTI1_IRQn);
  HAL_NVIC_EnableIRQ(EXTI3_IRQn);

  /* USER CODE END 2 */

  /* Infinite loop */
  while (1) {
	  HAL_Delay(1000);

  }
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void) {
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};
  RCC_PeriphCLKInitTypeDef PeriphClkInit = {0};

  /** Initializes the CPU, AHB and APB busses clocks 
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL4;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK) {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB busses clocks 
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_HSI;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_0) != HAL_OK) {
    Error_Handler();
  }
  PeriphClkInit.PeriphClockSelection = RCC_PERIPHCLK_USART1|RCC_PERIPHCLK_I2C1
                              |RCC_PERIPHCLK_ADC1;
  PeriphClkInit.Usart1ClockSelection = RCC_USART1CLKSOURCE_PCLK1;
  PeriphClkInit.I2c1ClockSelection = RCC_I2C1CLKSOURCE_SYSCLK;
  PeriphClkInit.Adc1ClockSelection = RCC_ADC1PLLCLK_DIV1;

  if (HAL_RCCEx_PeriphCLKConfig(&PeriphClkInit) != HAL_OK) {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart) {
	HAL_UART_Receive_IT(&huart1, RxBuff, 1); // Ready for new receiving
}

void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin) {
  if(GPIO_Pin == INT_1_Pin) {
	  status = VL53L1X_GetDistance(*arrayDevices[0], &rangeDistances[0]);
	  status = VL53L1X_ClearInterrupt(*arrayDevices[0]);
	  sensorsDataReady |= 0b00000001;
	  if(sensorsDataReady == 15){
		  sendMessage();
		  sensorsDataReady = 0;
	  }
  }
  if(GPIO_Pin == INT_2_Pin) {
	  status = VL53L1X_GetDistance(*arrayDevices[1], &rangeDistances[1]);
	  status = VL53L1X_ClearInterrupt(*arrayDevices[1]);
	  sensorsDataReady |= 0b00000010;
	  if(sensorsDataReady == 15){
		  sendMessage();
		  sensorsDataReady = 0;
	  }
  }
  if(GPIO_Pin == INT_3_Pin) {
	  status = VL53L1X_GetDistance(*arrayDevices[2], &rangeDistances[2]);
	  status = VL53L1X_ClearInterrupt(*arrayDevices[2]);
	  sensorsDataReady |= 0b00000100;
	  if(sensorsDataReady == 15) {
		  sendMessage();
		  sensorsDataReady = 0;
	  }
  }
  if(GPIO_Pin == INT_4_Pin) {
	  status = VL53L1X_GetDistance(*arrayDevices[3], &rangeDistances[3]);
	  status = VL53L1X_ClearInterrupt(*arrayDevices[3]);
	  sensorsDataReady |= 0b00001000;
	  if(sensorsDataReady == 15) {
		  sendMessage();
		  sensorsDataReady = 0;
	  }
  }
}


void chooseDevice(int DevNumber)
{
	switch(DevNumber) {
		case 1: HAL_GPIO_WritePin(XShut_1_GPIO_Port, XShut_1_Pin, GPIO_PIN_SET);
				break;
		case 2: HAL_GPIO_WritePin(XShut_1_GPIO_Port, XShut_2_Pin, GPIO_PIN_SET);
				break;
		case 3: HAL_GPIO_WritePin(XShut_1_GPIO_Port, XShut_3_Pin, GPIO_PIN_SET);
				break;
		case 4: HAL_GPIO_WritePin(XShut_1_GPIO_Port, XShut_4_Pin, GPIO_PIN_SET);
				break;
		default: break;
	}
}


void sendMessage(){
	//PSOTTY_START

	static bool nominalHeight = false;
	static uint8_t liveB = 0, nomCounter = 0;

	// ulozenie hodnot zo 4 snimacov
	if ((ptrData == NULL) || (ptrData + 3*LEN == ptrDataEnd))
		ptrData = ptrDataStart;
	else
		ptrData++;
	*ptrData = rangeDistances[0];
	*(ptrData + LEN) = rangeDistances[1];
	*(ptrData + 2*LEN) = rangeDistances[2];
	*(ptrData + 3*LEN) = rangeDistances[3];
	if ((counter == 0) && ((*ptrData < MAX_VAL) || (*(ptrData + LEN) < MAX_VAL) || (*(ptrData + 2*LEN) < MAX_VAL) || (*(ptrData + 3*LEN) < MAX_VAL))) {
		counter++;
		/*if (RxBuff[0] == '3' && (*ptrData > 100)) { // UPRAVIT NA RYCHLR PREJDENIE: COUNTER <= X   &&   RxBuff[0] == '3'
			messageBody[0] = 0; messageBody[1] = 0; messageBody[2] = 8;
			createMessage("CMD",messageBody);
		}*/
	}
	else if ((counter > 0) && (counter < LEN)) {
		if (((*ptrData > MAX_VAL) && (*(ptrData + LEN) > MAX_VAL) && (*(ptrData + 2*LEN) > MAX_VAL) && (*(ptrData + 3*LEN) > MAX_VAL))) {
			counterOut++;
		}
		else
			counterOut = 0;

		counter++;
	}

	// poslanie dat na analyzu po ukonceni gesta alebo uplynuti intervalu
	if ((counter == LEN) || (counterOut == 3)) {
		if (counter <= 5) {
			messageBody[0] = 0; messageBody[1] = 0; messageBody[2] = 8;
			createMessage("CMD",messageBody);
		}
		else {
			nominalHeight = gestureRecognition(ptrData, counter, ptrDataStart, RxBuff[0]);
		}
		counter = 0;
		counterOut = 0;
	}

	/*if ((counter == LEN) || (counterOut == 3)) {
		nominalHeight = gestureRecognition(ptrData, counter, ptrDataStart, RxBuff[0]);
		counter = 0;
		counterOut = 0;
	}*/

	else if (nominalHeight) {
		if (nomCounter == 3) {
			nominalHeight = gestureRecognition(ptrData, counter, ptrDataStart, RxBuff[0]);
			nomCounter = 0;
		}
		else
			nomCounter++;
	}
	//PSOTTY_END

	//HAL_HalfDuplex_EnableTransmitter(&huart1);

	// posielanie dat na vizualizaciu
	createMessage("D", rangeDistances);

	// ZATIAL NEVIEME
	if (liveB == 1) {
		liveByte();
		liveB = 0;
	}
	else
		liveB++;
	// SENDING RANGING DISTANCES THROUGH UART -- CAN will be used in the future
}

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */

  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(char *file, uint32_t line)
{ 
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     tex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

using System;

namespace ConsoleCalculator
{
    string  secondOperand="";
		string firstOperand="0";
		string consoleValue="0";
		char operatorValue='\0';
		bool decimalKey=false;
		
		private bool CheckValidInput(char key)
		{
		char[] validKeys = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', '-', '+', 'x', '/', 's', 'c', '=', 'X', 'S', 'X'};
		if (validKeys.Contains(key))
		{
			return true;
		}
		else
		{
			return false;
		}
		}
		
		private bool CheckValidOperator(char key)
		{
		char[] validKeys = {'/', '-', '+', 'x','X'};
		if (validKeys.Contains(key))
		{
			return true;
		}
		else
		{
			return false;
		}
		}
		
		private void ClearAll()
		{
			secondOperand="";
			firstOperand="0";
			consoleValue="0";
			operatorValue='\0';
			decimalKey=false;
		}
		
		public void DoCalculation()
        {
            if(operatorValue == '+')
            {
                firstOperand = (double.Parse(firstOperand) + double.Parse(secondOperand)).ToString();
				consoleValue=String.Copy(firstOperand);
            }
            else if(operatorValue == '-')
            {
                firstOperand = (double.Parse(firstOperand) - double.Parse(secondOperand)).ToString();
				consoleValue=String.Copy(firstOperand);
            }
            else if(operatorValue == '/')
            {
                if(secondOperand == "0")
                {
                    consoleValue = "-E-";
                }
                else
                {
                    firstOperand = (double.Parse(firstOperand) / double.Parse(secondOperand)).ToString();
					consoleValue=String.Copy(firstOperand);
                }
            }
            else if(operatorValue == 'x' || operatorValue == 'X')
            {
                firstOperand = (double.Parse(firstOperand) * double.Parse(secondOperand)).ToString();
				consoleValue=String.Copy(firstOperand);
            }
        }
		
        public string SendKeyPress(char key)
        {
            // Add your implementation here.
			if(CheckValidInput(key)== true)
			{
				if(key=='c' || key=='C')
				{
					ClearAll();
					consoleValue=String.Copy(firstOperand);
				}
				else if(key=='s' || key=='S')
				{
					if(operatorValue=='\0')
					{
						double changeSign=-1 * double.Parse(firstOperand);
						firstOperand=changeSign.ToString();
						consoleValue=String.Copy(firstOperand);
					}
					else
					{
						double changeSign=-1 * double.Parse(secondOperand);
						secondOperand=changeSign.ToString();
						consoleValue=String.Copy(secondOperand);
					}
					
				}
				else if(Char.IsDigit(key))
				{
					
					if (operatorValue=='\0')             
                    {
                        if ((firstOperand == "0" && key == '0')==false)
                        {
                            firstOperand = firstOperand + key;
                        }
						consoleValue=String.Copy(firstOperand);
                    }
                    else                        
                    {
                        if ((secondOperand == "0" && key == '0')==false)
                        {
                            secondOperand = secondOperand + key;
                        }
						consoleValue=String.Copy(secondOperand);
                    }
				}
		else if (key == '.')
                {
                    if (operatorValue=='\0' )                   
                    {
                        if(firstOperand.Contains('.')==false)
						{
                            firstOperand = firstOperand + ".";
							consoleValue=String.Copy(firstOperand);
						}
						else
						{
							consoleValue=String.Copy(firstOperand);
						}
                        
                    }
                    else            
                    {
                        if (secondOperand.Length == 0)
                        {
                            secondOperand = secondOperand + "0.";
							consoleValue=String.Copy(secondOperand);
                        }
                        else
                        {
							if(secondOperand.Contains('.')==false)
							{
								secondOperand = secondOperand + ".";
								consoleValue=String.Copy(secondOperand);
							}
							else
							{
								consoleValue=String.Copy(secondOperand);
							}
                        }
                    }
                }
				else if (CheckValidOperator(key))
                {
                    if (operatorValue!='\0')
                    {
                        DoCalculation();
                        secondOperand = "";
                    }
                    operatorValue = key;
                }
				else if (key == '=')
                {
                    DoCalculation();
                    operatorValue='\0';
                }
				
			}
			else
			{
				return consoleValue;
			}
			return consoleValue;
			
        }
}

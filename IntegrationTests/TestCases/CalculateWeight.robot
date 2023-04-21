*** Settings ***
Library     SeleniumLibrary

*** Variables ***
${browser}  chrome
${url}  https://localhost:7068/

*** Test Cases ***
EnterWeightWithDefaultValue
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     manoj.16@gmail.com
    input text  id:password     Manu@16
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath:/html/body/div/main/div/h1       Calculate Weight
    input text  xpath:/html/body/div/main/div/form/input[1]     30
    click element   xpath:/html/body/div/main/div/form/button
    close browser

EnterInValidWeightValue
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     manoj.16@gmail.com
    input text  id:password     Manu@16
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath:/html/body/div/main/div/h1       Calculate Weight
    input text  xpath:/html/body/div/main/div/form/input[1]     30kg
    Click Element   xpath:/html/body/div/main/div/form/select
    Mouse Down    xpath:/html/body/div/main/div/form/select/option[2]
    Click Element  xpath:/html/body/div/main/div/form/select/option[2]
    click element   xpath:/html/body/div/main/div/form/button
    close browser

*** Keywords ***
loginWithInValidUserNameAndPassword
    input text  id:id_username  Cambrian_Test
    input text  id:id_password  MNGT789
    click element  xpath://*[@id="loginForm"]/input[4]
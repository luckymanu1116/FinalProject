*** Settings ***
Library     SeleniumLibrary

*** Variables ***
${browser}  chrome
${url}  https://localhost:7068/

*** Test Cases ***
LoginWithInvalidUserName
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     Manoj
    input text  id:password     test
    click element  xpath://html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Login
    close browser

LoginWithInvalidPassword
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     manoj@gmail.com
    input text  id:password     test
    click element  xpath://html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Login
    close browser

LoginWithInValidUser
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     manoj@gmail.com
    input text  id:password     Test1
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath://html/body/div/main/div/h1       Login
    close browser

LoginWithValidUser
    open browser  ${url}     ${browser}
    maximize browser window
    input text  id:username     manoj.16@gmail.com
    input text  id:password     Manu@16
    click element  xpath:/html/body/div/main/div/form/button
    element text should be  xpath:/html/body/div/main/div/h1        Login
    close browser

*** Keywords ***
loginWithInValidUserNameAndPassword
    input text  id:id_username  manoj123
    input text  id:id_password  manu12345
    click element  xpath://*[@id="loginForm"]/input[4]
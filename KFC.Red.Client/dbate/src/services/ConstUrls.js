const apiURL = 'http://localhost:5000/api/'
//const apiURL = 'https://thedbateproject.azurewebsites.net/backend/api/'
//const KFCURL = 'https://kfc-sso.com'
const KFCURL = 'http://localhost:61348'
//const KFC_LoginURL = '"https://kfc-sso.com/#/login"'
const KFC_LoginURL = 'http://localhost:8081/#/login';
const chatServerURL = 'http://localhost:5000/signalr';

const URL = {
    randQuestURL: apiURL + 'question/randomquestion',
    sendMsgURL: apiURL + 'chat/postmessage',
    displayTelLogsURL: apiURL + 'log/displaytelemetrylogs',
    displayErrorLogsURL: apiURL + 'log/displayerrorlogs',
    deleteErrorLogsURL: apiURL + 'log/deletelog',
    publishAppURL: KFCURL + '/api/applications/publish',
    getQuestsURL: apiURL + 'question/getquestions',
    deleteQuestURL: apiURL + 'question/delete',
    addQuestURL: apiURL + 'question/add',
    getUserEmailURL: apiURL + 'user/getuseremail/',
    createChatURL: apiURL + 'chat/createchat',
    joinRandomChatURL: apiURL + 'chat/joinrandomchat',
    deleteGameSessionURL: apiURL + 'chat/deletegame',
    deleteUserGameURL: apiURL + 'chat/deleteuser',
    createTelemetryLogURL: apiURL + 'log/createtelemetrylogs',
    createUserGameLogURL: apiURL + 'chat/createusergame',
    logoutURL: apiURL + 'sso/logout',
    deleteSSOURL: apiURL + 'user/delete',
    postIPURL: apiURL + '',
    getPlayerCountURL: apiURL + 'chat/playercount',
    leaveGameURL: apiURL + 'chat/leavegame',
    useGSessionURL: apiURL + 'chat/usegsession',
    isGSessionUsedURL: apiURL + 'chat/isgsessionuse',
    assignHostURL: apiURL + 'api/gameplay/assignhost',
    assignPlayerURL: apiURL + 'api/gameplay/assignplayer',
    getOrderURL: apiURL + 'api/gameplay/getorder'
}

export {
    URL,
    KFCURL,
    KFC_LoginURL,
    chatServerURL
}
const apiURL = 'http://localhost:5000/api/'
const KFCURL = 'https://api.kfc-sso.com'

const URL = {
    randQuestURL: apiURL + 'question/randomquestion',
    sendMsgURL: apiURL + 'chat/postmessage',
    displayTelLogsURL: apiURL + 'telemetrylog/displaylogs',
    displayErrorLogsURL: apiURL + 'errorlog/displaylogs',
    deleteErrorLogsURL: apiURL + 'errorlog/deletelog',
    publishAppURL: KFCURL + '/api/applications/publish',
    getQuestsURL: apiURL + 'question/getquestions',
    deleteQuestURL: apiURL + 'question/delete',
    addQuestURL: apiURL + 'question/add',
    getUserURL: apiURL + 'user/getuser'
}

export {
    URL,
    KFCURL
}
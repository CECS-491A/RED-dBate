
const gameSessionToken = localStorage.getItem('gameSessionToken')

// initial state
const state = {
  playerAmount: 0,
  isPlayerMinimumMet: true,//false,
  playerList: [],
  messages: [],
  question: ''
}

// getters
const getters = {
  getPlayerAmount(state){
    return state.playerAmount;
  },
  getIsPlayerMinimumMet(state){
    return state.isPlayerMinimumMet;
  },
  getPlayerList(state){
    return state.playerList;
  },
  getQuestion(state){
    return state.question;
  },
  getMessages(state){
    return state.messages;
  }
}

// actions
const actions = {
  actIsPlayerMinimumMet (context, payload) {
    context.commit('mutateisPlayerMinimumMet', payload)
  },
  actPlayerAmount (context, payload) {
    context.commit('mutatePlayerAmount', payload)
  },
  actPlayerList (context, payload) {
    context.commit('mutateAddPlayerList',payload)
  },
  actQuestion (context, payload) {
    context.commit('mutateQuestion', payload)
  },
  actMessages (context, payload) {
    context.commit('mutateMessages', payload)
  },
  actDeleteMessages (context) {
    context.commit('mutateDeleteMessages')
  }
}

// mutations
const mutations = {
  mutateisPlayerMinimumMet (state, payload) {
    state.isPlayerMinimumMet = payload.IsPlayerMinimumMet
  },
  mutatePlayerAmount (state, payload) {
    state.playerAmount = payload.PlayerAmount
  },
  mutateAddPlayerList (state, player) {
    state.playerList.push(player)
  },
  mutateQuestion (state, payload) {
    state.question = payload.Question
  },
  mutateMessages (state, payload) {
    state.messages.push(payload.Messages)
  },
  mutateDeleteMessages (state) {
    state.messages = []
  }
}

export default {
  gameSessionToken,
  state,
  getters,
  actions,
  mutations
}

const gameSessionToken = localStorage.getItem('gameSessionToken')

// initial state
const state = {
  playerAmount: 0,
  isPlayerMinimumMet: true,//false,
  playerList: [],
  messages: [],
  question: '',
  gameRole: '',
  order: 0
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
  },
  getOrder(state){
    return state.order;
  },
  getGameRole(state){
    return state.gameRole;
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
  },
  actGameRole (context) {
    context.commit('mutateGameRole')
  },
  actOrder (context) {
    context.commit('mutateOrder')
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
  },
  mutateGameRole (state, payload) {
    state.gameRole = payload.GameRole
  },
  mutateOrder (state, payload) {
    state.order = payload.Order
  }
}

export default {
  gameSessionToken,
  state,
  getters,
  actions,
  mutations
}
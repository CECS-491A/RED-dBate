
const gameSessionToken = localStorage.getItem('gameSessionToken')

// initial state
const state = {
  playerAmount: 0,
  isPlayerMinimumMet: false,
  playerList: []
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
  }
}

export default {
  gameSessionToken,
  state,
  getters,
  actions,
  mutations
}
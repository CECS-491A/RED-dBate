
const gameSessionToken = localStorage.getItem('gameSessionToken')

// initial state
const state = {
  playerAmount: 0,
  isPlayerMinimumMet: false
}

// getters
const getters = {
  getPlayerAmount(state){
    return state.playerAmount;
  },
  getIsPlayerMinimumMet(state){
    return state.isPlayerMinimumMet;
  }
}

// actions
const actions = {
  actIsPlayerMinimumMet (context, payload) {
    context.commit('mutateisPlayerMinimumMet', payload)
  },
  actGetPlayerAmount (context, payload) {
    context.commit('mutatePlayerAmount', payload)
  }
}

// mutations
const mutations = {
  mutateisPlayerMinimumMet (state, payload) {
    state.viewprofile = payload.ViewProfile
  },
  mutatePlayerAmount (state, payload) {
    state.isLogin = payload.islogin
  }
}

export default {
  gameSessionToken,
  state,
  getters,
  actions,
  mutations
}
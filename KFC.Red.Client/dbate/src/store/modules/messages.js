// Bring in our constants (those we need in this file)
//import { NEW_MESSAGE, LOAD_MESSAGES } from '../mutation-constants'

// Initial state of our messages collection
// In practice, we'd have some initialization action, not a hardcoded message

const state = {
  items: [
    {
      text: 'Welcome to vuex chat!',
      sender: 'Vue.js'
    }
  ]
}

const mutations = {

  // Adds a message payload to store.state.messages.items
  ['NEW_MESSAGE'] (state, msg) {
    state.items.push(msg)
  },

  // Overwrites store.state.messages.items (for inits, etc)
  ['LOAD_MESSAGES'] (state, toLoad) {
    state.items = toLoad
  }
}

const actions = {

  newMessage ({commit}, msg) {
    commit('NEW_MESSAGE', msg)
  },

  loadMessages ({commit}, toLoad) {
    commit('LOAD_MESSAGES', toLoad)
  },

  resetMessages ({commit}) {
    commit('LOAD_MESSAGES', [])
  }
}

export default {
  state,
  mutations,
  actions
}
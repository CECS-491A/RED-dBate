import Vue from 'vue'
import Vuex from 'vuex'

// Set a debug boolean flag
const debug = process.env.NODE_ENV !== 'production'

// Use vuex
Vue.use(Vuex)
Vue.config.debug = debug

// Here's where we import the messages module
import messages from './modules/messages'

export default new Vuex.Store({

  state: {
    clientId: null
  },

  actions: {
  },

  getters: {
  },

  mutations: {
  },

  // This is where the messages module gets added to the Vuex store
  modules: {
    messages
  },

  // Use strict mode?
  strict: debug

})
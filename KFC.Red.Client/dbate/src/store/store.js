import Vue from 'vue'
import Vuex from 'vuex'
import user from './modules/user'
import game from './modules/game'
import createPersistedState from 'vuex-persistedstate'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  //...initialization
  modules: {
    game,
    user
  },
  plugins: [createPersistedState()],
  strict: debug
})
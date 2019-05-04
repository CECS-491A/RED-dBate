import Vue from 'vue'
import Vuex from 'vuex'
import user from './modules/user'
import game from './modules/game'
import GeneralService from './modules/GeneralServices'
import createPersistedState from 'vuex-persistedstate'

Vue.use(Vuex)

export default new Vuex.Store({
  //...initialization
  modules: {
    game,
    user,
    GeneralService,
  },
  plugins: [createPersistedState()],
})
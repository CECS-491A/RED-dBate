const state = {
    isSessionStored: false,
    adminPage: 0
  }
  
  const getters = {
    getAdminPage: function(state){
      return state.adminPage;
    },
    getIsSessionStored: function(state){
      return state.isSessionStored;
    }
  }

  // actions
const actions = {
  actAdminPage (context, payload) {
    context.commit('mutateAdminPage', payload);
  },
  actIsSessionStored (context, payload) {
    context.commit('mutateIsSessionStored', payload);
  }
}

// mutations
const mutations = {
  mutateAdminPage (state, payload) {
    state.adminPage = payload.AdminPage;
  },
  mutateIsSessionStored (state, payload) {
    state.isSessionStored = payload.IsSessionStored;
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
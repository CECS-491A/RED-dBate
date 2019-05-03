const state = {
    isSessionStored: true,
    adminPage: 0
  }
  
  const getters = {
    getAdminPage: function(state){
      return state.adminPage;
    },
  }

  // actions
const actions = {
  actAdminPage (context, payload) {
    context.commit('mutateAdminPage', payload)
  }

}

// mutations
const mutations = {
  mutateAdminPage (state, payload) {
    state.adminPage = payload.AdminPage
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
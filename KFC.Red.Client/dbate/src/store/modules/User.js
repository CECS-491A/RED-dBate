const state = {
    email: '',
    token: '',
    isLogin: false
  }
  
  const getters = {
    getEmail: function (state) {
      return state.email
    },
    getToken: function (state) {
      return state.token
    },
    getIsLogin: function (state) {
      return state.isLogin
    }
  }
  
  const actions = {
    actEmail (context, payload) {
      context.commit('mutateEMail', payload)
    },
    actToken (context, payload) {
      context.commit('mutateToken', payload)
    },
    actIsLogin (context, payload) {
      context.commit('mutateIsLogin', payload)
    }
  }
  
  const mutations = {
    mutateEmail (state, payload) {
      state.email = payload.Email
    },
    mutateToken (state, payload) {
      state.token = payload.Token
    },
    mutateIsLogin (state, payload) {
      state.isLogin = payload.Islogin
    }
  }
  
  export default {
    state,
    getters,
    actions,
    mutations
  }
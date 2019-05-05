const state = {
    email: '',
    token: '',
    isLogin: false,
    userPage: 0
  }
  
  const getters = {
    getEmail: function (state) {
      return state.email;
    },
    getToken: function (state) {
      return state.token;
    },
    getIsLogin: function (state) {
      return state.isLogin;
    },
    getUserPage: function (state) {
      return state.userPage;
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
    },
    actUserPage (context, payload) {
      context.commit('mutateUserPage', payload)
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
    },
    mutateUserPage (state,payload){
      state.userPage = payload.UserPage
    }
  }
  
  export default {
    state,
    getters,
    actions,
    mutations
  }
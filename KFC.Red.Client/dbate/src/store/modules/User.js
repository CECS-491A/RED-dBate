const state = {
    email: '',
    token: '',
    isLogin: false,
    userPage: 0,
    isAdmin: null
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
    },
    getisAdmin: function (state) {
      return state.isAdmin;
    }
  }
  
  const actions = {
    actEmail (context, payload) {
      context.commit('mutateEmail', payload)
    },
    actToken (context, payload) {
      context.commit('mutateToken', payload)
    },
    actIsLogin (context, payload) {
      context.commit('mutateIsLogin', payload)
    },
    actUserPage (context, payload) {
      context.commit('mutateUserPage', payload)
    },
    actIsAdmin (context, payload) {
      context.commit('mutateIsAdmin', payload)
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
    },
    mutateIsAdmin (state, payload){
      state.isAdmin = payload.IsAdmin
    }
  }
  
  export default {
    state,
    getters,
    actions,
    mutations
  }
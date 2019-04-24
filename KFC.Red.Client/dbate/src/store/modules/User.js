
const state = {
    username: '',
    token: '',
    isLogin: false,
    isPlaying: false
}

const mutations = {
    mutateusername (state, payload) {
        state.username = payload.Username
    },
    mutatetoken (state, payload) {
        state.token = payload.Token
    },
    mutateisPlaying (state, payload) {
        state.isPlaying = payload.isplaying
    },
    mutateisLogin (state, payload) {
        state.isLogin = payload.islogin
    }
}

const actions = {
    actusername (context, payload) {
        context.commit('mutateusername', payload)
    },
    acttoken (context, payload) {
        context.commit('mutatetoken', payload)
    },
    actisLogin (context, payload) {
        context.commit('mutateisLogin', payload)
    },
    actisPlaying (context, payload) {
        context.commit('mutateisPlaying', payload)
    }
}

const getters = {
    getusername: function (state) {
        return state.username
    },
    gettoken: function (state) {
        return state.token
    },
    getisLogin: function (state) {
        return state.isLogin
    },
    getisPlayinh: function (state) {
        return state.isPlaying
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
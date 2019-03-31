//import * as firebase from 'firebase'

const state = {
    chats: []
}

const mutations = {
    setMessagesEmpty (state) {
        state.messages = []
    },
    setChats (state, payload) {
        state.chats = payload
    }
}

const actions = {
    sendMessage ({commit}, payload) {
        let chatID = payload.chatID
        const message = {
          user: payload.username,
          content: payload.content,
          date: payload.date
        }

        //DO IT THE AXIOS WAY WITH CONTROLLER AND HUB
        /*firebase.database().ref('messages').child(chatID).child('messages').push(message)
          .then(
            (data) => {
            }
          )
          .catch(
            (error) => {
              console.log(error)
            }
          )*/
      },
      loadChats ({commit}) {
        /*firebase.database().ref('chats').on('value', function (snapshot) {
          commit('setChats', snapshot.val())
        })*/
      },
      createChat ({commit}, payload) {
        let newPostKey = firebase.database().ref().child('chats').push().key
        let updates = {}
        updates['/chats/' + newPostKey] = {name: payload.chatName}
        //firebase.database().ref().update(updates)
        return new Promise((resolve, reject) => {
          resolve(newPostKey)
        })
      }
}

const getters = {
    getmessages: function (state) {
        return state.messages
      },
      getchats: function (state) {
        return state.chats
      }  
}

export default {
    state,
    getters,
    actions,
    mutations
}
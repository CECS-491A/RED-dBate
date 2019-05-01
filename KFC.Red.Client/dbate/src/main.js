// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import Vuetify from 'vuetify'
import './../node_modules/bulma/css/bulma.css';
import 'vuetify/dist/vuetify.min.css' // Ensure you are using css-loader
import Vuex from 'vuex'

Vue.use(Vuetify, {
  theme: {
    primary: '#2c3e50',
    secondary: '#ffffff',
    accent: '#8c9eff',
    error: '#b71c1c'
  }
})

Vue.use(Vuex)

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})

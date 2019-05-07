<template>
  <div>
     <div v-if="loading">
      <Loading :dialog="loading" :text="loadingText"/>
    </div>
    <div v-if="!validSession">
      <PopupDialog :dialog="!validSession" :text="popupMessage" redirect=true :redirectUrl="KFCURL"/>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import Loading from '@/components/dialogs/Loading'
import PopupDialog from '@/components/dialogs/PopupDialog'
import {KFCURL} from '@/services/ConstUrls'
import {URL} from '@/services/ConstUrls'

export default {
  name: 'Login',
  components: {
    Loading,
    PopupDialog
  },
  data: () => ({
    token: '',
    loading: false,
    loadingText: '',
    validSession: true,
    popupMessage: '',
  }),
  mounted() {
    this.token = this.$route.query.token;
    localStorage.setItem('token', this.token);
    this.$store.dispatch('actIsSessionStored', {IsSessionStored: true});
    this.CheckUser(this.token);
  },
  methods: {
    CheckUser(token) {
      this.loading = true;
      this.loadingText = 'Logging In...';
      axios.get(URL.getUserEmailURL + `${token}`, {
          params: {
          token: this.token
        }
      })
      .then(resp => {
            var userEmail = resp.data;
            localStorage.setItem('token', this.token);
            console.log(localStorage.getItem('token'));
            this.$store.dispatch('actEmail', {Email: userEmail});
            this.$store.dispatch('actIsSessionStored', {IsSessionStored: true});
            this.loading = false;
            this.loadingText = '';
            this.$router.push('/lobby');
      })
      .catch( e => {
        this.loading = false;
        this.loadingText = '';
      })
    }
  }
}
</script>
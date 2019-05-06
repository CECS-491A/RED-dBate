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
import Loading from '@/components/reusable-components/dialogs/Loading'
import PopupDialog from '@/components/reusable-components/dialogs/PopupDialog'
import {KFCURL} from '@/services/ConstUrls'

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
    this.CheckUser(this.token);
  },
  methods: {
    CheckUser(token) {
      this.loading = true;
      this.loadingText = 'Logging In...';
      axios.get('http://localhost:5000/api/user/getuser')
      .then(resp => {
        switch(resp.response.status){
          case 200:
            var user = resp.data;
            localStorage.setItem('token', this.token);
            this.loading = false;
            this.loadingText = '';
            this.$router.push('/lobby');
          default:
        }
      })
      .catch( e => {
        this.loading = false;
        this.loadingText = '';
      })
    }
  }
}
</script>
<template>
  <div>
     <div v-if="loading">
      <Loading :dialog="loading" :text="loadingText"/>
    </div>
    <div v-if="!validSession">
      <PopupDialog :dialog="!validSession" :text="popupMessage" redirect=true :redirectUrl="redirectUrl"/>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import Loading from '@/components/reusable-components/dialogs/Loading'
import PopupDialog from '@/components/reusable-components/dialogs/PopupDialog'
import { GetUser } from '@/services/uMServices'
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
    redirectUrl: 'https://kfc-sso.com'
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
      GetUser()
        .then( response => {
          switch(response.status){
            case 200:
              var user = response.data;
              localStorage.setItem('token', this.token);
              this.loading = false;
              this.loadingText = '';
              this.$router.push('/questmanagement');
            default:
          }
        })
        .catch( err => {
          this.loading = false;
          this.loadingText = '';
          if (err.response){
            switch(err.response.status){
              case 404:
                this.loading = false;
                this.popupMessage = 'The session has expired...';
                this.validSession = false;
                break;
              default:
            }
          } 
          else{
            this.loading = false;
            this.popupMessage = 'This application has encounted a problem...';
            this.validSession = false;
          }
        })
    }
  }
}
</script>
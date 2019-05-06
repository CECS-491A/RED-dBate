const state = {
    isSessionStored: true
  }
  
  const getters = {
    getIsSessionStored: function(){
        if(localStorage.getItem('token') !== null){
            this.getIsSessionStored = true;
            return true;
        }
        else{
          this.getIsSessionStored = false;
          return false;
        }
    }
  }
  
  
  export default {
    state,
    getters
  }
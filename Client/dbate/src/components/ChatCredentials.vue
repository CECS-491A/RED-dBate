<template>
    <div class="cred-wrapper">
        <form class="form-cred" @submit.prevent="start">
            <h2 class="form-cred-heading">Chat Credentials</h2>
            <input v-model="username" id="username" type="username" class="form-control" placeholder="Username" required>
            <button class="start" type="submit">Submit</button>
        </form>
    </div>
</template>

<script>
export default {
    name: 'chatcred',
    data () {
      return {
        username: '',
      }
    },
    beforeMount () {

    },
    methods: {
      start (){
        var name = this.username;
        if (name.length > 0) {
            localStorage.setItem('username',name)
            this.$router.push('/chat')
        }
        else {
            alert("Please enter name");
        }
    }
}
 }
</script>

<style>
    .cred-wrapper {
        background: #fff;
        width: 100%;
        height: 100%;
        margin: 1px auto;
        text-align: center;
    }
    .form-cred {
        max-width: 330px;
        padding: 5% 10px;
        margin: 0 auto;
    }
    .form-cred .form-control {
        position: relative;
        height: auto;
        -webkit-box-sizing: border-box;
            box-sizing: border-box;
        padding: 10px;
        font-size: 16px;
    }
    .form-cred .form-control:focus {
        z-index: 2;
    }
    .form-cred input {
        border: .5px solid #555;
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        box-sizing: border-box;
    }
    .form-cred button {
        background: #778899;
        width: 100%;
        height: 40px;
    }
</style
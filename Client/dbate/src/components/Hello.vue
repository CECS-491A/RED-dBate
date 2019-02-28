<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'hello',
  data () {
    return {
      msg: "f" 
    }
  },
  mounted(){
    //axios.get('http://localhost/backend/api/home').then(msg2 => {this.msg2 = msg2.data; console.log(this.msg2);})
    axios.get('http://localhost:5000/api/home').then(msg => {this.msg = msg.data; console.log(this.msg);})
    //axios.get('https://dbate.azurewebsites.net/backend/api/home').then(msg2 => {this.msg2 = msg2.data; console.log(this.msg2);})
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
h1, h2 {
  font-weight: normal;
}

ul {
  list-style-type: none;
  padding: 0;
}

li {
  display: inline-block;
  margin: 0 10px;
}

a {
  color: #35495E;
}
</style>

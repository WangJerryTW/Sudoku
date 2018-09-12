<template>
  <div>
    <h1 style="text-align:center">數獨遊戲</h1>
    <ul>
        <li v-for="item in sudo">
            <router-link :to="'sudoku/'+item.id">{{ item.id }}</router-link>
            <span v-if="item.tag==1">very easy</span>
            <span v-else-if="item.tag==2">easy</span>
        </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'Index',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      sudo:[]
    }
  },
  created () {
    this.axios.get('http://api.pureday.life/sudo/')
      .then(response => (this.sudo = response.data))
  }
}
</script>

<style>
  li{
    padding:5px;
    font-size:22px;
  }
  a{
    color:white;
  }
</style>

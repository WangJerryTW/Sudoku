<template>
  <div>
    <h1 style="text-align:center">數獨遊戲</h1>
    <div style="text-align:center"><router-link to="admin/">後台管理</router-link></div>
    <ul>
        <li v-for="item in sudo" :key="item.id">
            <router-link :to="'sudoku/'+item.id">{{ item.id }}</router-link>&nbsp;&nbsp;&nbsp;&nbsp;
            <span v-if="item.tag==1">very easy</span>
            <span v-else-if="item.tag==2">easy</span>
            <span v-else-if="item.tag==3">medium</span>
            <span v-else-if="item.tag==4">hard</span>
            <span v-else-if="item.tag==5">very hard</span>
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

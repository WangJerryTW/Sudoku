<template>
  <div class="row justify-content-center">
    <div class="col col-md-6 col-12">
      <h1 class="text-center">數獨遊戲</h1>
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
      <hr>
      <div class="text-center">
        <router-link to="admin/">後台管理</router-link> | Copyright © 2018 <a href="https://www.pureday.life/">純生活網</a>
      </div>
    </div>
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
    this.axios.get('sudo/')
      .then(response => (this.sudo = response.data))
  }
}
</script>

<style>
  body {
  background-color: #354242;
}
</style>

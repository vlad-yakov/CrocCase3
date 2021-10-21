<template>
  
  <schedule msg="Calendar"/>
</template>

<script>
import schedule from './components/Schedule.vue'

export default {
  name: 'App',
  components: {
    schedule
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

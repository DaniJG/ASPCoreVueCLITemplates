<template>
  <div class="sample-api">
    <h1>Sample page fetching data from the ValuesController</h1>
    <h3>These are the initial values:</h3>
    <ul class="values-list">
      <li v-for="value in values" :key="value">{{ value }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'sample-api',
  data () {
    return {
      values: []
    }
  },
  created () {
    // Send request to the ASP.NET Core application.
    // Either send request to https://localhost:5001/api/values or setup vue dev proxy and send it to /api/values
    return fetch('https://localhost:5001/api/values')
      .then(res => res.json())
      .then(data => { this.values = data })
  }
}
</script>

<style scoped>
.values-list {
  list-style: none;
}
</style>

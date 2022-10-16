<template>
  <div id="app">
    <b-breadcrumb align="is-left">
      <b-breadcrumb-item tag="router-link" to="/">Home</b-breadcrumb-item>
      <b-breadcrumb-item tag="router-link" to="/dict">Dict</b-breadcrumb-item>
      <b-breadcrumb-item tag="router-link" to="/about">About</b-breadcrumb-item>
    </b-breadcrumb>
    <router-view />
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}
</style>

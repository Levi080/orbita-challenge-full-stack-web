<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title>Gestão de Alunos</v-toolbar-title>
    </v-app-bar>

    <v-navigation-drawer app>
      <v-list-item>
        <v-list-item-title class="text-h6">
          Módulo Acadêmico
        </v-list-item-title>
      </v-list-item>

      <v-divider></v-divider>

      <v-list nav>
        <v-list-item link to="/" color="primary">
          <v-list-item-icon>
            <v-icon>mdi-account</v-icon>
          </v-list-item-icon>
          <v-list-item-title>Alunos</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <v-container fluid>
        <router-view></router-view>
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup>
</script>
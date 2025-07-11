<template>
  <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Módulo Acadêmico</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
  </head>

  <body></body>

  <header class="main-header">
    <img src="@/assets/logo-grupoa.png" alt="Logo" class="header-logo"/>
  </header>

  <div class="sidenav">
    <div>
      <h5>Módulo Acadêmico</h5>
    </div>

    <div class="items">
      <a href="#Students">Alunos</a>
    </div>
  </div>

  <div class="main-content">
    <div class="student-box">
      <a>Consulta de Alunos</a>
    </div>

    <div class="search-box">
      <div>
        <input v-model="search" type="text" placeholder="Digite o nome" class="px-3 py-2 rounded"/>
        <button class="px-4 py-2 rounded" @click="filterStudents">Pesquisar</button>
      </div>

      <button class="px-4 py-2 rounded">Cadastrar Aluno</button>
    </div>

    <div class="students-list-box">
      <table class="min-w-full border-collapse border border-gray-300">
        <thead class="bg-gray-300 text-left">
          <tr>
            <th class="p-2 border border-gray-300">Registro Acadêmico</th>
            <th class="p-2 border border-gray-300">Nome</th>
            <th class="p-2 border border-gray-300">Email</th>
            <th class="p-2 border border-gray-300">CPF</th>
            <th class="p-2 border border-gray-300">Ações</th>
          </tr>
        </thead>
          <tbody>
            <tr
            v-for="student in students"
            :key="student.id"
            class="even:bg-gray-100"
            >
              <td class="p-2 border border-gray-300">{{ student.academicRegistry }}</td>
              <td class="p-2 border border-gray-300">{{ student.name }}</td>
              <td class="p-2 border border-gray-300">{{ student.email }}</td>
              <td class="p-2 border border-gray-300">{{ student.cpf }}</td>
              <td class="p-2 border border-gray-300">
                <a href="#" class="text-blue-600 mr-2">[Editar]</a>
                <a href="#" class="text-red-600">[Excluir]</a>
              </td>
            </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<style scoped src="@/assets/students/index.css"></style>
<script setup>
import { studentsIndex } from '@/scripts/students/index.js'

const {
  search,
  students,
  filterStudents
} = studentsIndex()
</script>
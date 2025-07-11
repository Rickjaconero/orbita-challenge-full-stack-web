import { ref, computed, onMounted } from 'vue'
import axios, { Axios } from 'axios';

export function studentsIndex() {

  onMounted(async () => {
    await getStudentsList();
  });

  const students = ref([])
  const search = ref('')

  async function getStudentsList() {
    
    const response = await axios.get("https://localhost:7006/students");
    students.value = response.data
  }

  async function filterStudents() {
    const response = await axios.get(`https://localhost:7006/students?name=${search.value}`);
    students.value = response.data
  }

  return {
    search,
    students,
    filterStudents
  }
}
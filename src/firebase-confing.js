import { initializeApp } from 'firebase/app'
import { getFirestore } from 'firebase/firestore/lite'
// Import the functions you need from the SDKs you need


// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyCpZ3wJfrfseCiuQhXIyqvBjMtDIWiyxM8",
  authDomain: "mkr2vue.firebaseapp.com",
  projectId: "mkr2vue",
  storageBucket: "mkr2vue.appspot.com",
  messagingSenderId: "843434241167",
  appId: "1:843434241167:web:ce543efd03e03d8ac054fa"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);

const db = getFirestore(app)
export default db
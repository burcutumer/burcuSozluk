import Login from "./account/Login";
import Register from "./account/Register";
import EntriesPage from "./components/EntriesPage";
import Header from "./components/Header"
import Sidebar from "./components/Sidebar"
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { useStoreContext } from "./context/StoreContext";
import { useEffect } from "react";
import agent from "./api/agent";
import EntryPage from "./components/EntryPage";

function App() {

  const { user, setUser, userLoading, setUserLoading } = useStoreContext();

  useEffect(() => {
    const jwt = localStorage.getItem("jwt")
    if (userLoading || (jwt && !user)) {
      agent.Account.currentUser()
        .then(user => {
          setUser(user.data)
          console.log(user.data)
        })
        .catch(e => localStorage.removeItem("jwt"))
        .finally(() => setUserLoading(false))
    }
  }, [user, setUser, userLoading])

  return (
    <Router>
      <>
        <Header />
        <div className="flex pt-32 h-screen">
          <Sidebar />
          <Routes>
            <Route path='/' element={<EntriesPage />} />
            <Route path='/login' element={<Login />} />
            <Route path='/register' element={<Register />} />
            <Route path='/entry/:id' element={<EntryPage />} />
            <Route path='*' element={<EntriesPage />} />
          </Routes>

        </div>
      </>
    </Router>
  );
}

export default App
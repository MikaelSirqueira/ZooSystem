import { Routes, Route } from "react-router-dom";
import PageNotFound from "./pages/PageNotFound";
import Animal from "./pages/animais/Animal";
import Cuidado from "./pages/cuidados/Cuidado";
import Home from "./pages/home/Home";

const App = () => {
  return (
    <Routes>
      <Route path="/" element={<Home/>} />
      <Route path="/animal/" element={<Animal />} />
      <Route path="/care/" element={<Cuidado />} />
      <Route element={<PageNotFound />} />
    </Routes>
  );
};

export default App;

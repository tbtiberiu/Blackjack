import "./App.css";
import Table from "./components/Table";
import GameContextProvider from "./contexts/GameContext";


function App() {
  return (
    <GameContextProvider>
      <Table />
    </GameContextProvider>
  );
}

export default App;

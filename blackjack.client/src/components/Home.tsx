import React from "react";
import styles from "./styles/Home.module.css";
import { useDispatch } from "react-redux";
import Table from "./Table";
import { startNewGameAsync } from "../context/game-slice";
import { useState } from "react";
import { UnknownAction } from "@reduxjs/toolkit";

const HomePage = () => {
  const dispatch = useDispatch();
  const [gameState, setGameState] = useState<any>(false);

  const handleStartNewGame = () => {
    dispatch(startNewGameAsync() as unknown as UnknownAction);
    setGameState(true);
  };

  return (
    <>
      {gameState ? (
        <Table />
      ) : (
        <div className={styles.container}>
          <div className={styles.title}>Blackjack</div>
          <button className={styles.button} onClick={handleStartNewGame}>
            New Game
          </button>
        </div>
      )}
    </>
  );
};

export default HomePage;

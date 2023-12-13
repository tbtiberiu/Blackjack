import React, { useContext } from "react";
import styles from "./styles/Commands.module.css";
import { GameContext } from "../contexts/GameContext";

const Commands: React.FC = () => {
  const { startNewGame, deal, hit, stand } = useContext(GameContext);

  const handleStartNewGame = () => {
    startNewGame();
  };

  const handleDeal = () => {
    deal();
  };

  const handleHit = () => {
    hit();
  };

  const handleStand = () => {
    stand();
  };

  return (
    <div className={styles.commands}>
      <button className={styles.button} onClick={handleStartNewGame}>
        New Game
      </button>
      <button className={styles.button} onClick={handleDeal}>
        Deal
      </button>
      <button className={styles.button} onClick={handleHit}>
        Hit
      </button>
      <button className={styles.button} onClick={handleStand}>
        Stand
      </button>
    </div>
  );
};

export default Commands;

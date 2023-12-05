import React from "react";
import styles from "./styles/Commands.module.css";

const Commands: React.FC = () => {
  return (
    <div className={styles.commands}>
      <button className={styles.button}>New Game</button>  
      <button className={styles.button}>Deal</button>
      <button className={styles.button}>Hit</button>
      <button className={styles.button}>Stand</button>
    </div>
  );
};

export default Commands;
import React from "react";
import styles from "./styles/Table.module.css";
import Hand from "./Hand";
import Commands from "./Commands";
import { Suits } from "../enums/suits";

const Table: React.FC = () => {
  return (
    <>
      <div className={styles.table}>
        <div className={styles.hands}>
          <Hand
            cards={[
              { value: "A", suit: Suits.Hearts, hidden: true },
              { value: "K", suit: Suits.Diamonds, hidden: false },
            ]}
          />

          <Hand
            cards={[
              { value: "A", suit: Suits.Clubs, hidden: false },
              { value: "6", suit: Suits.Diamonds, hidden: false },
            ]}
          />
        </div>

        <div className={styles.deck}></div>
      </div>
      <div className={styles.commands}>
        <Commands />
      </div>
    </>
  );
};

export default Table;

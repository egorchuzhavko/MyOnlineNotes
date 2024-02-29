import styles from './MainpageHeader.module.css';

interface props {
  username: string;
  toggle: () => void;
}

const MainpageHeader = ({ username, toggle }: props) => {
  return (
    <div className={styles.shell}>
      <div className={styles.container}>
        <h1>{username}'s notes</h1>
        <a onClick={toggle}>create note</a>
      </div>
    </div>
  );
};

export default MainpageHeader;

import { useState } from 'react';
import { NotesService } from '../../../../../../services/Notes.service';
import styles from './noteItemPopup.module.css';

const NoteItemPopup = ({ userId, note, isOpen, toggle }: ModalType) => {
  const [text, setText] = useState('');

  const Delete = async () => {
    const response = await NotesService.deleteNote(note.id);
    if (response) {
      alert('You successfully deleted your note');
      toggle();
    } else {
      alert('An error was found when deleting your note..');
    }
  };

  const Update = async () => {
    console.log(note.note);
    const response = await NotesService.updateNote(note.id, {
      note: text,
      userId: userId,
    });
    if (response) {
      alert('You successfully updated your note');
    } else {
      alert('An error was found when updating your note..');
    }
  };

  return (
    <>
      {isOpen && (
        <div className={styles.modalOverlay} onClick={toggle}>
          <div className={styles.modalBox} onClick={e => e.stopPropagation()}>
            <h1 className={styles.headernote}>My note</h1>
            <div className={styles.line}></div>
            <textarea
              className={styles.customTextArea}
              onChange={e => setText(e.target.value)}
              defaultValue={note.note}
            ></textarea>
            <div className={styles.centerbtn}>
              <button className={styles.btn} onClick={Update}>
                Save
              </button>
              <button className={styles.btn} onClick={Delete}>
                Delete
              </button>
            </div>
          </div>
        </div>
      )}
    </>
  );
};

export default NoteItemPopup;

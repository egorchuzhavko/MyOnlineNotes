import { useForm } from 'react-hook-form';
import { FaUserAlt } from 'react-icons/fa';
import { RiLockPasswordFill } from 'react-icons/ri';
import { Link } from 'react-router-dom';
import { RegistrationService } from '../../../services/Registration.service';
import styles from './Registration.module.css';

const Registration = () => {
  const { register, handleSubmit, formState } = useForm<IRegisterForm>();
  const { errors } = formState;

  async function submit(data: IRegisterForm) {
    if (data.password != data.repeatPassword) {
      alert('Passwords are NOT the same');
      return;
    }
    const result = await RegistrationService.registerUser({
      login: data.username,
      password: data.password,
    });

    if (result) {
      alert('You successfully logined');
    } else {
      alert('Wrong login or password');
    }
  }

  return (
    <div className={styles.shell}>
      <div className={styles.container}>
        <form onSubmit={handleSubmit(submit)}>
          <h1>Registration</h1>
          <div className={styles.inputBox}>
            <input
              type='text'
              {...register('username', {
                required: {
                  value: true,
                  message: 'Username is required',
                },
              })}
              placeholder='Username'
            />
            <FaUserAlt className={styles.icon} />
          </div>
          <p className={styles.error}>{errors.username?.message}</p>
          <div className={styles.inputBox}>
            <input
              type='password'
              {...register('password', {
                required: {
                  value: true,
                  message: 'Password is required',
                },
              })}
              placeholder='Password'
            />
            <RiLockPasswordFill className={styles.icon} />
          </div>
          <p className={styles.error}>{errors.password?.message}</p>
          <div className={styles.inputBox}>
            <input
              type='password'
              {...register('repeatPassword', {
                required: {
                  value: true,
                  message: 'Repeat password is required',
                },
              })}
              placeholder='Repeat password'
            />
            <RiLockPasswordFill className={styles.icon} />
          </div>
          <p className={styles.error}>{errors.repeatPassword?.message}</p>
          <button>Register</button>
          <div className={styles.registerLink}>
            <p>
              Already have an account? <Link to='/login'>Log in</Link>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Registration;

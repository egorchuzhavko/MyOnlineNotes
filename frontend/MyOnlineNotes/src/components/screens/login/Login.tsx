import { useForm } from 'react-hook-form';
import { FaUserAlt } from 'react-icons/fa';
import { RiLockPasswordFill } from 'react-icons/ri';
import { Link, useNavigate } from 'react-router-dom';
import { LoginService } from '../../../services/Login.service';
import styles from './Login.module.css';

const Login = () => {
  const { register, handleSubmit, formState } = useForm<IRegisterForm>();
  const { errors } = formState;

  const navigate = useNavigate();

  async function submit(data: IRegisterForm) {
    const result = await LoginService.loginUser({
      login: data.username,
      password: data.password,
    });
    if (result) {
      const user = await LoginService.getUserByLogin(data.username);
      navigate('/mynotes', { state: { id: user.id, username: user.login } });
    } else {
      alert('-');
    }
  }

  return (
    <div className={styles.shell}>
      <div className={styles.container}>
        <form onSubmit={handleSubmit(submit)}>
          <h1>Log in</h1>
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
          <button>Login</button>
          <div className={styles.registerLink}>
            <p>
              Don't have an account? <Link to='/registration'>Register</Link>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
};

export default Login;

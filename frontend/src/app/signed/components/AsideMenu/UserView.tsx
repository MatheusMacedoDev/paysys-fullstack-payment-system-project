import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export default function UserView() {
    return (
        <div className="flex items-center gap-5">
            <div className="w-16 h-16 rounded-full bg-green-300 flex justify-center items-center">
                <FontAwesomeIcon
                    className="text-green-950 w-8 h-8"
                    icon={faUser}
                />
            </div>
            <p className="font-semibold text-lg text-green-300">
                Olá, Usuário.
            </p>
        </div>
    );
}

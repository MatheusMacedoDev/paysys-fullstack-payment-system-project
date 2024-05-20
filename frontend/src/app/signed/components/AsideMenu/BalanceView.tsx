import { faEye } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export default function BalanceView() {
    return (
        <div className="w-full h-28 bg-green-300 rounded-xl mt-10 flex justify-between items-center text-green-950 p-7">
            <div className="flex flex-col">
                <span className="font-light text-xs">Saldo em conta:</span>
                <span className="font-bold text-lg">R$1999,87</span>
            </div>
            <FontAwesomeIcon className="text-xl" icon={faEye} />
        </div>
    );
}

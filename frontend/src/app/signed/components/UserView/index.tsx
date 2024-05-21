import { SizeOptions, getUserGreetingTextStyle } from './styleOptions';
import DefaultUserIcon from './DefaultUserIcon';

interface UserViewProps {
    size: SizeOptions;
}

export default function UserView({ size }: UserViewProps) {
    const userGreetingTextStyle = getUserGreetingTextStyle(size);

    return (
        <div className="flex items-center gap-5">
            <DefaultUserIcon size={size} />
            <p className={userGreetingTextStyle}>Olá, Usuário.</p>
        </div>
    );
}

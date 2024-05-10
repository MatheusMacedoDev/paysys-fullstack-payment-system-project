import Link from 'next/link';
import Button from '../Button';

export default function DesktopMenu() {
    return (
        <div className="lg:flex lg:items-center lg:gap-8 hidden">
            <Link href="" className="font-semibold text-base">
                Cadastro
            </Link>

            <Button title="Entrar" className="text-base" />
        </div>
    );
}

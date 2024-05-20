import Button from '@/components/Button';
import Link from 'next/link';

export default function DesktopMenu() {
    return (
        <div className="lg:flex lg:items-center lg:gap-8 hidden">
            <Link href="" className="font-semibold text-md">
                Cadastro
            </Link>

            <Button title="Entrar" className="text-md" />
        </div>
    );
}

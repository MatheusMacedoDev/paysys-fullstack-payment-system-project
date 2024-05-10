import Footer from '@/components/Footer';
import Header from '@/components/Header';

export default function pocPage() {
    return (
        <div className="w-screen h-screen">
            <Header />
            <div className="h-28 w-28 bg-gradient-to-t from-green-100 to-green-200"></div>
            <p className="text-xl font-extrabold tracking-wider">Raleway</p>

            <Footer />
        </div>
    );
}

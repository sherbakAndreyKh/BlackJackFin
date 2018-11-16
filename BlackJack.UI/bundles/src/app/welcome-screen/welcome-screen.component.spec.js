import { async, TestBed } from '@angular/core/testing';
import { WelcomeScreenComponent } from './welcome-screen.component';
describe('WelcomeScreenComponent', function () {
    var component;
    var fixture;
    beforeEach(async(function () {
        TestBed.configureTestingModule({
            declarations: [WelcomeScreenComponent]
        })
            .compileComponents();
    }));
    beforeEach(function () {
        fixture = TestBed.createComponent(WelcomeScreenComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });
    it('should create', function () {
        expect(component).toBeTruthy();
    });
});
//# sourceMappingURL=welcome-screen.component.spec.js.map